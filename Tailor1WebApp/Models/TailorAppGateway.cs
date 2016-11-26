using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;


namespace Tailor1WebApp.Models
{
    public class TailorAppGateway
    {
        private SqlConnection connection;        
        public TailorAppGateway()
        {
            //string conn = @"server=MINHAZ; database=TailorDB;integrated security=true";
            //string conn = @"server=MINHAZ-PC\SQLEXPRESS; database=TailorDB;integrated security=true";
            connection = new SqlConnection();
            //string conn = ConfigurationManager.ConnectionStrings["TailorTest"].ConnectionString;
            string conn = ConfigurationManager.ConnectionStrings["TailorDB"].ConnectionString;
            connection.ConnectionString = conn;
            
        }

        #region Customer
        public string SaveCustomer(Customer aCustomer)
        {
            connection.Open();
            string query = string.Format("INSERT INTO Customer VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}')", aCustomer.CustomerIDNo, aCustomer.Name, aCustomer.Department, aCustomer.MobileNo, aCustomer.Gender, aCustomer.Address, aCustomer.CustomerType,aCustomer.Designation,aCustomer.WorkStation);
            SqlCommand command = new SqlCommand(query, connection);

            int affectedRows = command.ExecuteNonQuery();
            connection.Close();
            if (affectedRows > 0)
                return "Customer Saved successfully";
            return "something wrong....";
        }
        public List<Customer> GetAllCustomer()
        {
            connection.Open();
            string query = string.Format("SELECT * FROM Customer ORDER BY CustomerID DESC");
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader aReader = command.ExecuteReader();
            List<Customer> customers = new List<Customer>();
            if (aReader.HasRows)
            {
                while (aReader.Read())
                {
                    Customer aCustomer = new Customer();
                    aCustomer.CustomerID = (int)aReader[0];
                    aCustomer.CustomerIDNo = aReader[1].ToString();
                    aCustomer.Name = aReader[2].ToString();
                    aCustomer.Department = aReader[3].ToString();
                    aCustomer.MobileNo = aReader[4].ToString();
                    aCustomer.Gender = aReader[5].ToString();
                    aCustomer.Address = aReader[6].ToString();
                    aCustomer.CustomerType = aReader[7].ToString();
                    aCustomer.Designation = aReader[8].ToString();
                    aCustomer.WorkStation = aReader[9].ToString();

                    customers.Add(aCustomer);
                }
            }
            connection.Close();
            return customers;
        }
        public List<Customer> GetAllCustomerByName(string customerName)
        {
            connection.Open();
            string query = string.Format("SELECT * FROM Customer WHERE Name LIKE '%{0}%'", customerName);
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader aReader = command.ExecuteReader();
            List<Customer> customers = new List<Customer>();            
            if (aReader.HasRows)
            {
                while (aReader.Read())
                {
                    Customer aCustomer = new Customer();
                    aCustomer.CustomerID = (int)aReader[0];
                    aCustomer.CustomerIDNo = aReader[1].ToString();
                    aCustomer.Name = aReader[2].ToString();
                    aCustomer.Department = aReader[3].ToString();
                    aCustomer.MobileNo = aReader[4].ToString();
                    aCustomer.Gender = aReader[5].ToString();
                    aCustomer.Address = aReader[6].ToString();
                    aCustomer.CustomerType = aReader[7].ToString();
                    aCustomer.Designation = aReader[8].ToString();
                    aCustomer.WorkStation = aReader[9].ToString();
                    customers.Add(aCustomer);
                }
            }
            connection.Close();
            return customers;
        }
        public List<Customer> GetAllCustomerByID(string customerID)
        {
            connection.Open();
            string query = string.Format("SELECT * FROM Customer WHERE CustomerIDNo LIKE '%{0}%'", customerID);
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader aReader = command.ExecuteReader();
            List<Customer> customers = new List<Customer>();
            if (aReader.HasRows)
            {
                while (aReader.Read())
                {
                    Customer aCustomer = new Customer();
                    aCustomer.CustomerID = (int)aReader[0];
                    aCustomer.CustomerIDNo = aReader[1].ToString();
                    aCustomer.Name = aReader[2].ToString();
                    aCustomer.Department = aReader[3].ToString();
                    aCustomer.MobileNo = aReader[4].ToString();
                    aCustomer.Gender = aReader[5].ToString();
                    aCustomer.Address = aReader[6].ToString();
                    aCustomer.CustomerType = aReader[7].ToString();
                    aCustomer.Designation = aReader[8].ToString();
                    aCustomer.WorkStation = aReader[9].ToString();
                    customers.Add(aCustomer);
                }
            }
            connection.Close();
            return customers;
        }
        public List<Customer> GetAllCustomerByMobile(string customerMobile)
        {
            connection.Open();
            string query = string.Format("SELECT * FROM Customer WHERE MobileNo LIKE '%{0}%'", customerMobile);
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader aReader = command.ExecuteReader();
            List<Customer> customers = new List<Customer>();
            if (aReader.HasRows)
            {
                while (aReader.Read())
                {
                    Customer aCustomer = new Customer();
                    aCustomer.CustomerID = (int)aReader[0];
                    aCustomer.CustomerIDNo = aReader[1].ToString();
                    aCustomer.Name = aReader[2].ToString();
                    aCustomer.Department = aReader[3].ToString();
                    aCustomer.MobileNo = aReader[4].ToString();
                    aCustomer.Gender = aReader[5].ToString();
                    aCustomer.Address = aReader[6].ToString();
                    aCustomer.CustomerType = aReader[7].ToString();
                    aCustomer.Designation = aReader[8].ToString();
                    aCustomer.WorkStation = aReader[9].ToString();
                    customers.Add(aCustomer);
                }
            }
            connection.Close();
            return customers;
        }
        public bool HasThisCustomer(string CustomerIdNumber)
        {
            connection.Open();
            String query = String.Format("SELECT * FROM Customer WHERE CustomerIDNo='{0}'", CustomerIdNumber);
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader aReader = command.ExecuteReader();
            bool Hassrow = aReader.HasRows;
            connection.Close();
            return Hassrow;
        }
        public int GetMaxCustomerID()
        {
            connection.Open();
            string query = string.Format("SELECT MAX(CustomerID) FROM Customer");
            SqlCommand command = new SqlCommand(query, connection);

            int maxId = Convert.ToInt32(command.ExecuteScalar());
            return maxId;
            connection.Close();
        }
        public string GetCustomerNameByID(int CustomerID)
        {
            connection.Open();
            string query = string.Format("SELECT Name FROM Customer WHERE CustomerID ='{0}'", CustomerID);
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader aReader = command.ExecuteReader();
            string customerName = "";
            while (aReader.Read())
            {
                customerName = (string)aReader["Name"];
            }
            connection.Close();
            return customerName;
        }
        public List<Customer> GetAllCustomerByCustomerID(int customerID)
        {
            connection.Open();
            string query = string.Format("SELECT * FROM Customer WHERE CustomerID ='{0}'", customerID);
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader aReader = command.ExecuteReader();
            List<Customer> customers = new List<Customer>();
            if (aReader.HasRows)
            {
                while (aReader.Read())
                {
                    Customer aCustomer = new Customer();
                    aCustomer.CustomerID = (int)aReader[0];
                    aCustomer.CustomerIDNo = aReader[1].ToString();
                    aCustomer.Name = aReader[2].ToString();
                    aCustomer.Department = aReader[3].ToString();
                    aCustomer.MobileNo = aReader[4].ToString();
                    aCustomer.Gender = aReader[5].ToString();
                    aCustomer.Address = aReader[6].ToString();
                    aCustomer.CustomerType = aReader[7].ToString();
                    aCustomer.Designation = aReader[8].ToString();
                    aCustomer.WorkStation = aReader[9].ToString();

                    customers.Add(aCustomer);
                }
            }
            connection.Close();
            return customers;
        }
        public string UpdateCustomer(Customer aCustomer, int customerIdHidden)
        {
            connection.Open();
            string query = string.Format("UPDATE customer SET Address='{0}', CustomerIDNo='{1}',CustomerType='{2}',Department='{3}',Gender='{4}',MobileNo='{5}',Name='{6}',Designation='{7}',WorkStation='{8}' WHERE CustomerID={9}", aCustomer.Address, aCustomer.CustomerIDNo, aCustomer.CustomerType, aCustomer.Department, aCustomer.Gender, aCustomer.MobileNo, aCustomer.Name,aCustomer.Designation,aCustomer.WorkStation, customerIdHidden);
            SqlCommand command = new SqlCommand(query, connection);

            int affectedRows = command.ExecuteNonQuery();
            connection.Close();
            if (affectedRows > 0)
                return "Customer Updated successfully";
            return "Something wrong..!!";
        }

        #endregion

        #region User
        public string SaveUser(User aUser)
        {
            connection.Open();
            string query = string.Format("INSERT INTO UserInfo VALUES('{0}','{1}','{2}','{3}')", aUser.LoginID, aUser.Password, aUser.FullName, aUser.MobileNo);
            SqlCommand command = new SqlCommand(query, connection);

            int affectedRows = command.ExecuteNonQuery();
            connection.Close();
            if (affectedRows > 0)
                return "You are Registered, now LogIn";
            return "something went wrong, try again ";
        }
        public bool HasThisName(string userName)
        {
            connection.Open();
            String query = String.Format("SELECT * FROM UserInfo WHERE LoginID='{0}'", userName);
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader aReader = command.ExecuteReader();
            bool Hassrow = aReader.HasRows;
            connection.Close();
            return Hassrow;
        }
        public bool HasThisPassword(string password)
        {
            connection.Open();
            String query = String.Format("SELECT * FROM UserInfo WHERE Password='{0}'", password);
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader aReader = command.ExecuteReader();
            bool Hassrow = aReader.HasRows;
            connection.Close();
            return Hassrow;
        }
        public bool HasThisNamePassword(string userName, string Password)
        {
            connection.Open();
            String query = String.Format("SELECT * FROM UserInfo WHERE LoginID='{0}' AND Password='{1}'", userName, Password);
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader aReader = command.ExecuteReader();
            bool Hassrow = aReader.HasRows;
            connection.Close();
            return Hassrow;
        }
        public List<User> GetUserInfoByUserID(string loginID)
        {
            connection.Open();
            string query = string.Format("SELECT * FROM UserInfo WHERE LoginID LIKE'{0}'", loginID);
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader aReader = command.ExecuteReader();
            List<User> users = new List<User>();
            if (aReader.HasRows)
            {
                while (aReader.Read())
                {
                    User aUser = new User();
                    aUser.UserID = (int)aReader[0];
                    aUser.LoginID = aReader[1].ToString();
                    aUser.Password = aReader[2].ToString();
                    aUser.FullName = aReader[3].ToString();
                    aUser.MobileNo = aReader[4].ToString();

                    users.Add(aUser);
                }
            }
            connection.Close();
            return users;
        }

        #endregion

        #region Measurement
        public string SaveMeasurement(Measurement aMeasurement)
        {
            connection.Open();
            string query = string.Format("INSERT INTO Measurement VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}')", aMeasurement.CustomerID, aMeasurement.DressTypeID, aMeasurement.Length, aMeasurement.Chest, aMeasurement.WaistBelly, aMeasurement.Hip, aMeasurement.Shoulder, aMeasurement.SleeveLength, aMeasurement.CuffOpening, aMeasurement.Neck, aMeasurement.AllRoundRise, aMeasurement.Thaigh, aMeasurement.BottomOpening);
            SqlCommand command = new SqlCommand(query, connection);

            int affectedRows = command.ExecuteNonQuery();
            connection.Close();
            if (affectedRows > 0)
                return "Measurement saved successfully";
            return "Saving Error........!!";
        }
        public List<DressMeasurement> GetDressMeasurementListByCustomerID(int CustomerID)
        {
            connection.Open();
            string query = string.Format("SELECT Measurement.MeasurementID,Customer.CustomerID,Customer.CustomerIDNo,Customer.Name,DressType.TypeName,DressType.Price,DressType.DressTypeID FROM Measurement INNER JOIN Customer ON Measurement.CustomerID=Customer.CustomerID INNER JOIN DressType on Measurement.DressTypeID = DressType.DressTypeID WHERE Customer.CustomerID ='{0}'", CustomerID);

            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader aReader = command.ExecuteReader();
            List<DressMeasurement> dressMeasurements = new List<DressMeasurement>();
            if (aReader.HasRows)
            {
                while (aReader.Read())
                {
                    DressMeasurement aDressMeasurement = new DressMeasurement();
                    aDressMeasurement.DressMeasurementID = (int)aReader[0];
                    aDressMeasurement.CustomerID = (int)aReader[1];
                    aDressMeasurement.CustomerIDNo = aReader[2].ToString();
                    aDressMeasurement.DressType = aReader[4].ToString();
                    aDressMeasurement.DressPrice = Convert.ToInt64(aReader[5]);
                    aDressMeasurement.DressTypeID = (int)aReader[6];

                    dressMeasurements.Add(aDressMeasurement);
                }
            }
            connection.Close();
            return dressMeasurements;
        }
        public List<Measurement> GetAllMeasurement()
        {
            connection.Open();
            string query = string.Format("SELECT * FROM Measurement ORDER BY MeasurementID DESC");
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader aReader = command.ExecuteReader();
            List<Measurement> measurements = new List<Measurement>();
            if (aReader.HasRows)
            {
                while (aReader.Read())
                {
                    Measurement aMeasurement = new Measurement();
                    aMeasurement.MeasurementID = (int)aReader[0];
                    aMeasurement.CustomerID = (int)aReader[1];
                    aMeasurement.DressTypeID = (int)aReader[2];
                    aMeasurement.Length = (double)aReader[3];
                    aMeasurement.Chest = (double)aReader[4];
                    aMeasurement.WaistBelly = (double)aReader[5];
                    aMeasurement.Hip = (double)aReader[6];
                    aMeasurement.Shoulder = (double)aReader[7];
                    aMeasurement.SleeveLength = (double)aReader[8];
                    aMeasurement.CuffOpening = (double)aReader[9];
                    aMeasurement.Neck = (double)aReader[10];
                    aMeasurement.AllRoundRise = (double)aReader[11];
                    aMeasurement.Thaigh = (double)aReader[12];
                    aMeasurement.BottomOpening = (double)aReader[13];

                    measurements.Add(aMeasurement);
                }
            }
            connection.Close();
            return measurements;
        }
        public List<CustomerMeasurement> GetAllCustomerMeasurement()
        {
            connection.Open();
            string query = string.Format("SELECT Measurement.* ,DressType.TypeName,Customer.Name,Customer.CustomerIDNo,Customer.MobileNo FROM Measurement INNER JOIN Customer on Measurement.CustomerID = Customer.CustomerID INNER JOIN DressType on Measurement.DressTypeID = DressType.DressTypeID ORDER BY MeasurementID DESC");
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader aReader = command.ExecuteReader();
            List<CustomerMeasurement> customerMeasurements = new List<CustomerMeasurement>();
            if (aReader.HasRows)
            {
                while (aReader.Read())
                {
                    CustomerMeasurement aCustomerMeasurement = new CustomerMeasurement();
                    aCustomerMeasurement.MeasurementID = (int)aReader[0];
                    aCustomerMeasurement.CustomerID = (int)aReader[1];
                    aCustomerMeasurement.DressTypeID = (int)aReader[2];
                    aCustomerMeasurement.Length = (double)aReader[3];
                    aCustomerMeasurement.Chest = (double)aReader[4];
                    aCustomerMeasurement.WaistBelly = (double)aReader[5];
                    aCustomerMeasurement.Hip = (double)aReader[6];
                    aCustomerMeasurement.Shoulder = (double)aReader[7];
                    aCustomerMeasurement.SleeveLength = (double)aReader[8];
                    aCustomerMeasurement.CuffOpening = (double)aReader[9];
                    aCustomerMeasurement.Neck = (double)aReader[10];
                    aCustomerMeasurement.AllRoundRise = (double)aReader[11];
                    aCustomerMeasurement.Thaigh = (double)aReader[12];
                    aCustomerMeasurement.BottomOpening = (double)aReader[13];
                    aCustomerMeasurement.DressTypeName = aReader[14].ToString();
                    aCustomerMeasurement.CustomerName = aReader[15].ToString();
                    aCustomerMeasurement.CustomerIDCard = aReader[16].ToString();
                    aCustomerMeasurement.CustomerMobile = aReader[17].ToString();

                    customerMeasurements.Add(aCustomerMeasurement);
                }
            }
            connection.Close();
            return customerMeasurements;
        }
        public List<CustomerMeasurement> GetAllCustomerMeasurementByName(string customername)
        {
            connection.Open();
            string query = string.Format("SELECT Measurement.* ,DressType.TypeName,Customer.Name,Customer.CustomerIDNo,Customer.MobileNo FROM Measurement INNER JOIN Customer on Measurement.CustomerID = Customer.CustomerID INNER JOIN DressType on Measurement.DressTypeID = DressType.DressTypeID WHERE Customer.Name LIKE '%{0}%' ORDER BY MeasurementID DESC", customername);
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader aReader = command.ExecuteReader();
            List<CustomerMeasurement> customerMeasurements = new List<CustomerMeasurement>();
            if (aReader.HasRows)
            {
                while (aReader.Read())
                {
                    CustomerMeasurement aCustomerMeasurement = new CustomerMeasurement();
                    aCustomerMeasurement.MeasurementID = (int)aReader[0];
                    aCustomerMeasurement.CustomerID = (int)aReader[1];
                    aCustomerMeasurement.DressTypeID = (int)aReader[2];
                    aCustomerMeasurement.Length = (double)aReader[3];
                    aCustomerMeasurement.Chest = (double)aReader[4];
                    aCustomerMeasurement.WaistBelly = (double)aReader[5];
                    aCustomerMeasurement.Hip = (double)aReader[6];
                    aCustomerMeasurement.Shoulder = (double)aReader[7];
                    aCustomerMeasurement.SleeveLength = (double)aReader[8];
                    aCustomerMeasurement.CuffOpening = (double)aReader[9];
                    aCustomerMeasurement.Neck = (double)aReader[10];
                    aCustomerMeasurement.AllRoundRise = (double)aReader[11];
                    aCustomerMeasurement.Thaigh = (double)aReader[12];
                    aCustomerMeasurement.BottomOpening = (double)aReader[13];
                    aCustomerMeasurement.DressTypeName = aReader[14].ToString();
                    aCustomerMeasurement.CustomerName = aReader[15].ToString();
                    aCustomerMeasurement.CustomerIDCard = aReader[16].ToString();
                    aCustomerMeasurement.CustomerMobile = aReader[17].ToString();

                    customerMeasurements.Add(aCustomerMeasurement);
                }
            }
            connection.Close();
            return customerMeasurements;
        }
        public List<CustomerMeasurement> GetCustomerMeasurementByCustomerID(int customerid)
        {
            connection.Open();
            string query = string.Format("SELECT Measurement.* ,DressType.TypeName,Customer.Name,Customer.CustomerIDNo,Customer.MobileNo FROM Measurement INNER JOIN Customer on Measurement.CustomerID = Customer.CustomerID INNER JOIN DressType on Measurement.DressTypeID = DressType.DressTypeID WHERE Customer.CustomerID = '{0}' ORDER BY MeasurementID DESC", customerid);
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader aReader = command.ExecuteReader();
            List<CustomerMeasurement> customerMeasurements = new List<CustomerMeasurement>();
            if (aReader.HasRows)
            {
                while (aReader.Read())
                {
                    CustomerMeasurement aCustomerMeasurement = new CustomerMeasurement();
                    aCustomerMeasurement.MeasurementID = (int)aReader[0];
                    aCustomerMeasurement.CustomerID = (int)aReader[1];
                    aCustomerMeasurement.DressTypeID = (int)aReader[2];
                    aCustomerMeasurement.Length = (double)aReader[3];
                    aCustomerMeasurement.Chest = (double)aReader[4];
                    aCustomerMeasurement.WaistBelly = (double)aReader[5];
                    aCustomerMeasurement.Hip = (double)aReader[6];
                    aCustomerMeasurement.Shoulder = (double)aReader[7];
                    aCustomerMeasurement.SleeveLength = (double)aReader[8];
                    aCustomerMeasurement.CuffOpening = (double)aReader[9];
                    aCustomerMeasurement.Neck = (double)aReader[10];
                    aCustomerMeasurement.AllRoundRise = (double)aReader[11];
                    aCustomerMeasurement.Thaigh = (double)aReader[12];
                    aCustomerMeasurement.BottomOpening = (double)aReader[13];
                    aCustomerMeasurement.DressTypeName = aReader[14].ToString();
                    aCustomerMeasurement.CustomerName = aReader[15].ToString();
                    aCustomerMeasurement.CustomerIDCard = aReader[16].ToString();
                    aCustomerMeasurement.CustomerMobile = aReader[17].ToString();

                    customerMeasurements.Add(aCustomerMeasurement);
                }
            }
            connection.Close();
            return customerMeasurements;
        }
        public List<CustomerMeasurement> GetAllCustomerMeasurementByMobile(string customerMobile)
        {
            connection.Open();
            string query = string.Format("SELECT Measurement.* ,DressType.TypeName,Customer.Name,Customer.CustomerIDNo,Customer.MobileNo FROM Measurement INNER JOIN Customer on Measurement.CustomerID = Customer.CustomerID INNER JOIN DressType on Measurement.DressTypeID = DressType.DressTypeID WHERE Customer.MobileNo LIKE '%{0}%' ORDER BY MeasurementID DESC", customerMobile);
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader aReader = command.ExecuteReader();
            List<CustomerMeasurement> customerMeasurements = new List<CustomerMeasurement>();
            if (aReader.HasRows)
            {
                while (aReader.Read())
                {
                    CustomerMeasurement aCustomerMeasurement = new CustomerMeasurement();
                    aCustomerMeasurement.MeasurementID = (int)aReader[0];
                    aCustomerMeasurement.CustomerID = (int)aReader[1];
                    aCustomerMeasurement.DressTypeID = (int)aReader[2];
                    aCustomerMeasurement.Length = (double)aReader[3];
                    aCustomerMeasurement.Chest = (double)aReader[4];
                    aCustomerMeasurement.WaistBelly = (double)aReader[5];
                    aCustomerMeasurement.Hip = (double)aReader[6];
                    aCustomerMeasurement.Shoulder = (double)aReader[7];
                    aCustomerMeasurement.SleeveLength = (double)aReader[8];
                    aCustomerMeasurement.CuffOpening = (double)aReader[9];
                    aCustomerMeasurement.Neck = (double)aReader[10];
                    aCustomerMeasurement.AllRoundRise = (double)aReader[11];
                    aCustomerMeasurement.Thaigh = (double)aReader[12];
                    aCustomerMeasurement.BottomOpening = (double)aReader[13];
                    aCustomerMeasurement.DressTypeName = aReader[14].ToString();
                    aCustomerMeasurement.CustomerName = aReader[15].ToString();
                    aCustomerMeasurement.CustomerIDCard = aReader[16].ToString();
                    aCustomerMeasurement.CustomerMobile = aReader[17].ToString();

                    customerMeasurements.Add(aCustomerMeasurement);
                }
            }
            connection.Close();
            return customerMeasurements;
        }
        public string UpdateMeasurement(Measurement aMeasurement, int measurementHiddenID)
        {
            connection.Open();
            string query = string.Format("UPDATE Measurement SET AllRoundRise='{0}', BottomOpening='{1}',Chest='{2}',CuffOpening='{3}',CustomerID='{4}',DressTypeID='{5}',Hip='{6}',Length='{7}',Neck='{8}',Shoulder='{9}',SleeveLength='{10}',Thaigh='{11}',WaistBelly='{12}' WHERE MeasurementID={13}", aMeasurement.AllRoundRise, aMeasurement.BottomOpening, aMeasurement.Chest, aMeasurement.CuffOpening, aMeasurement.CustomerID, aMeasurement.DressTypeID, aMeasurement.Hip, aMeasurement.Length, aMeasurement.Neck, aMeasurement.Shoulder, aMeasurement.SleeveLength, aMeasurement.Thaigh, aMeasurement.WaistBelly, measurementHiddenID);
            SqlCommand command = new SqlCommand(query, connection);

            int affectedRows = command.ExecuteNonQuery();
            connection.Close();
            if (affectedRows > 0)
                return "Measurement Updated successfully";
            return "Something wrong..!!";
        }
        public List<Measurement> GetAllMeasurementBymeasurementID(int measurementID)
        {
            connection.Open();
            string query = string.Format("SELECT * FROM Measurement WHERE MeasurementID ='{0}'", measurementID);
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader aReader = command.ExecuteReader();
            List<Measurement> measurements = new List<Measurement>();
            if (aReader.HasRows)
            {
                while (aReader.Read())
                {
                    Measurement aMeasurement = new Measurement();
                    aMeasurement.MeasurementID = (int)aReader[0];
                    aMeasurement.CustomerID = (int)aReader[1];
                    aMeasurement.DressTypeID = (int)aReader[2];
                    aMeasurement.Length = Convert.ToInt64(aReader[3]);
                    aMeasurement.Chest = Convert.ToInt64(aReader[4]);
                    aMeasurement.WaistBelly = Convert.ToInt64(aReader[5]);
                    aMeasurement.Hip = Convert.ToInt64(aReader[6]);
                    aMeasurement.Shoulder = Convert.ToInt64(aReader[7]);
                    aMeasurement.SleeveLength = Convert.ToInt64(aReader[8]);
                    aMeasurement.CuffOpening = Convert.ToInt64(aReader[9]);
                    aMeasurement.Neck = Convert.ToInt64(aReader[10]);
                    aMeasurement.AllRoundRise = Convert.ToInt64(aReader[11]);
                    aMeasurement.Thaigh = Convert.ToInt64(aReader[12]);
                    aMeasurement.BottomOpening = Convert.ToInt64(aReader[13]);
                    measurements.Add(aMeasurement);
                }
            }
            connection.Close();
            return measurements;
        }

        #endregion

        #region Order

        public string SaveOrder(Order aOrder)
        {
            connection.Open();
            string query = string.Format("INSERT INTO OrderInfo VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}')", aOrder.CustomerID, aOrder.OrderNo, aOrder.OrderDate, aOrder.DeliveryDate, aOrder.Quantity, aOrder.Price, aOrder.PaidAmount, aOrder.Discount, aOrder.PaymentStatus, aOrder.DeliveryStatus, aOrder.DueAmount, aOrder.CancilStatus,aOrder.Remarks);
            SqlCommand command = new SqlCommand(query, connection);

            int affectedRows = command.ExecuteNonQuery();
            connection.Close();
            if (affectedRows > 0)
                return "Order Saved successfully";
            return "Saving Error.....!!";
        }
        public List<Order> GetAllOrder()
        {
            connection.Open();
            string query = string.Format("SELECT * FROM OrderInfo ORDER BY OrderID DESC");
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader aReader = command.ExecuteReader();
            List<Order> orders = new List<Order>();
            if (aReader.HasRows)
            {
                while (aReader.Read())
                {
                    Order aOrder = new Order();
                    aOrder.OrderID = (int)aReader[0];
                    aOrder.CustomerID = (int)aReader[1];
                    aOrder.OrderNo = aReader[2].ToString();
                    aOrder.OrderDate = Convert.ToDateTime(aReader[3]);
                    aOrder.DeliveryDate = Convert.ToDateTime(aReader[4]);
                    aOrder.Quantity = (int)aReader[5];
                    aOrder.Price = (double)aReader[6];
                    aOrder.PaidAmount = (double)aReader[7];
                    aOrder.Discount = (double)aReader[8];
                    aOrder.PaymentStatus = (int)aReader[9];
                    aOrder.DeliveryStatus = (int)aReader[10];
                    aOrder.DueAmount = (double)aReader[11];
                    aOrder.CancilStatus = (int)aReader[12];
                    aOrder.Remarks = aReader[13].ToString();
                    orders.Add(aOrder);
                }
            }
            connection.Close();
            return orders;
        }
        public int GetOrderIDbyOrderNo(string OrderNo)
        {
            connection.Open();
            string query = string.Format("SELECT OrderID FROM OrderInfo WHERE OrderNo LIKE '{0}'", OrderNo);
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader aReader = command.ExecuteReader();
            int Id = 0;
            while (aReader.Read())
            {
                Id = (int)aReader["OrderID"];
            }
            connection.Close();
            return Id;
        }
        public bool HasThisOrderNo(string OrderNumber)
        {
            connection.Open();
            String query = String.Format("SELECT * FROM OrderInfo WHERE OrderNo='{0}'", OrderNumber);
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader aReader = command.ExecuteReader();
            bool Hassrow = aReader.HasRows;
            connection.Close();
            return Hassrow;
        }
        public List<Order> GetAllUndeliveredOrder()
        {
            connection.Open();
            //int DeliveryStatus = 1;
            string query = string.Format("SELECT * FROM OrderInfo WHERE DeliveryStatus={0} AND PaymentStatus={1} AND CancilStatus={2} Order by OrderInfo.DeliveryDate DESC", 1, 1, 1);
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader aReader = command.ExecuteReader();
            List<Order> orders = new List<Order>();
            if (aReader.HasRows)
            {
                while (aReader.Read())
                {
                    Order aOrder = new Order();
                    aOrder.OrderID = (int)aReader[0];
                    aOrder.CustomerID = (int)aReader[1];
                    aOrder.OrderNo = aReader[2].ToString();
                    aOrder.OrderDate = Convert.ToDateTime(aReader[3]);
                    aOrder.DeliveryDate = Convert.ToDateTime(aReader[4]);
                    aOrder.Quantity = (int)aReader[5];
                    aOrder.Price = (double)aReader[6];
                    aOrder.PaidAmount = (double)aReader[7];
                    aOrder.Discount = (double)aReader[8];
                    aOrder.PaymentStatus = (int)aReader[9];
                    aOrder.DeliveryStatus = (int)aReader[10];
                    aOrder.DueAmount = (double)aReader[11];
                    aOrder.CancilStatus = (int)aReader[12];
                    aOrder.Remarks = aReader[13].ToString();
                    orders.Add(aOrder);
                }
            }
            connection.Close();
            return orders;
        }
        public List<Order> GetAllDeliveredOrder()
        {
            connection.Open();
            //int DeliveryStatus = 0;
            //int PaymentStatus = 0;
            string query = string.Format("SELECT * FROM OrderInfo WHERE DeliveryStatus={0} AND PaymentStatus={1} AND CancilStatus={2} Order by OrderInfo.DeliveryDate DESC", 0, 0, 1);
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader aReader = command.ExecuteReader();
            List<Order> orders = new List<Order>();
            if (aReader.HasRows)
            {
                while (aReader.Read())
                {
                    Order aOrder = new Order();
                    aOrder.OrderID = (int)aReader[0];
                    aOrder.CustomerID = (int)aReader[1];
                    aOrder.OrderNo = aReader[2].ToString();
                    aOrder.OrderDate = Convert.ToDateTime(aReader[3]);
                    aOrder.DeliveryDate = Convert.ToDateTime(aReader[4]);
                    aOrder.Quantity = (int)aReader[5];
                    aOrder.Price = (double)aReader[6];
                    aOrder.PaidAmount = (double)aReader[7];
                    aOrder.Discount = (double)aReader[8];
                    aOrder.PaymentStatus = (int)aReader[9];
                    aOrder.DeliveryStatus = (int)aReader[10];
                    aOrder.DueAmount = (double)aReader[11];
                    aOrder.CancilStatus = (int)aReader[12];
                    aOrder.Remarks = aReader[13].ToString();
                    orders.Add(aOrder);
                }
            }
            connection.Close();
            return orders;
        }
        public List<Order> GetAllCanceledOrder()
        {
            connection.Open();
           // int CancilStatus = 0;
            string query = string.Format("SELECT * FROM OrderInfo WHERE CancilStatus={0} Order by OrderInfo.DeliveryDate DESC", 0);
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader aReader = command.ExecuteReader();
            List<Order> orders = new List<Order>();
            if (aReader.HasRows)
            {
                while (aReader.Read())
                {
                    Order aOrder = new Order();
                    aOrder.OrderID = (int)aReader[0];
                    aOrder.CustomerID = (int)aReader[1];
                    aOrder.OrderNo = aReader[2].ToString();
                    aOrder.OrderDate = Convert.ToDateTime(aReader[3]);
                    aOrder.DeliveryDate = Convert.ToDateTime(aReader[4]);
                    aOrder.Quantity = (int)aReader[5];
                    aOrder.Price = (double)aReader[6];
                    aOrder.PaidAmount = (double)aReader[7];
                    aOrder.Discount = (double)aReader[8];
                    aOrder.PaymentStatus = (int)aReader[9];
                    aOrder.DeliveryStatus = (int)aReader[10];
                    aOrder.DueAmount = (double)aReader[11];
                    aOrder.CancilStatus = (int)aReader[12];
                    aOrder.Remarks = aReader[13].ToString();
                    orders.Add(aOrder);
                }
            }
            connection.Close();
            return orders;
        }
        public List<Order> GetAllUndeliveredOrderByOrderNo(string searchText)
        {
            connection.Open();
            //string query = string.Format("SELECT * FROM OrderInfo WHERE OrderNo LIKE'%{0}%'", searchText);
            string query = string.Format("SELECT * FROM OrderInfo WHERE OrderNo LIKE'%{0}%' AND DeliveryStatus='{1}'  ", searchText, 1);
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader aReader = command.ExecuteReader();
            List<Order> orders = new List<Order>();
            if (aReader.HasRows)
            {
                while (aReader.Read())
                {
                    Order aOrder = new Order();
                    aOrder.OrderID = (int)aReader[0];
                    aOrder.CustomerID = (int)aReader[1];
                    aOrder.OrderNo = aReader[2].ToString();
                    aOrder.OrderDate = Convert.ToDateTime(aReader[3]);
                    aOrder.DeliveryDate = Convert.ToDateTime(aReader[4]);
                    aOrder.Quantity = (int)aReader[5];
                    aOrder.Price = (double)aReader[6];
                    aOrder.PaidAmount = (double)aReader[7];
                    aOrder.Discount = (double)aReader[8];
                    aOrder.PaymentStatus = (int)aReader[9];
                    aOrder.DeliveryStatus = (int)aReader[10];
                    aOrder.DueAmount = (double)aReader[11];
                    aOrder.CancilStatus = (int)aReader[12];
                    aOrder.Remarks = aReader[13].ToString();
                    orders.Add(aOrder);
                }
            }
            connection.Close();
            return orders;
        }
        public string SaveOrderDetails(OrderDetail aOrderDetail)
        {
            connection.Open();
            string query = string.Format("INSERT INTO OrderDetail VALUES('{0}','{1}','{2}','{3}')", aOrderDetail.OrderID, aOrderDetail.DressTypeID, aOrderDetail.Quantity, aOrderDetail.Price);
            SqlCommand command = new SqlCommand(query, connection);

            int affectedRows = command.ExecuteNonQuery();
            connection.Close();
            if (affectedRows > 0)
                return "OrderDetail Save successfully";
            return "something wrong";
        }
        public int GetMaxOrderID()
        {
            connection.Open();
            string query = string.Format("SELECT MAX(OrderID) FROM OrderInfo");
            SqlCommand command = new SqlCommand(query, connection);

            int maxOrderIDId = Convert.ToInt32(command.ExecuteScalar());
            return maxOrderIDId;
            connection.Close();
        }

        public List<CustomerDressOrder> GetCustomerDressOrderListByOrderNo(string OrderNo)
        {
            connection.Open();
            string query = string.Format("SELECT OrderInfo.OrderID,OrderInfo.OrderNo,Customer.Name CustomerName,DressType.TypeName DressType,OrderDetail.Quantity  DressQuantity,OrderInfo.OrderDate,OrderInfo.DeliveryDate,Customer.Designation FROM OrderInfo INNER JOIN OrderDetail ON OrderDetail.OrderID=OrderInfo.OrderID INNER JOIN Customer ON Customer.CustomerID=OrderInfo.CustomerID INNER JOIN DressType ON DressType.DressTypeID=OrderDetail.DressTypeID WHERE OrderInfo.CancilStatus = 1 AND OrderInfo.OrderNo LIKE '%{0}%'", OrderNo);
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader aReader = command.ExecuteReader();
            List<CustomerDressOrder> customerDressOrders = new List<CustomerDressOrder>();
            if (aReader.HasRows)
            {
                while (aReader.Read())
                {
                    CustomerDressOrder aCustomerDressOrder = new CustomerDressOrder();
                    aCustomerDressOrder.CustomerDressOrderID = (int)aReader[0];
                    aCustomerDressOrder.OrderNo = aReader[1].ToString();
                    aCustomerDressOrder.CustomerName = aReader[2].ToString();
                    aCustomerDressOrder.DressType = aReader[3].ToString();
                    aCustomerDressOrder.DressQuantity = (int)aReader[4];
                    aCustomerDressOrder.OrderDate = Convert.ToDateTime(aReader[5]);
                    aCustomerDressOrder.DeliveryDate = Convert.ToDateTime(aReader[6]);
                    aCustomerDressOrder.Designation = aReader[7].ToString();
                    

                    customerDressOrders.Add(aCustomerDressOrder);
                }
            }
            connection.Close();
            return customerDressOrders;
        }

        #endregion

        #region Dress Type
        public List<DressType> GetAllDressType()
        {
            connection.Open();
            string query = string.Format("SELECT * FROM DressType");
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader aReader = command.ExecuteReader();
            List<DressType> dressTypes = new List<DressType>();
            if (aReader.HasRows)
            {
                while (aReader.Read())
                {
                    DressType aDressType = new DressType();
                    aDressType.DressTypeID = (int)aReader[0];
                    aDressType.TypeName = aReader[1].ToString();
                    aDressType.DressPrice = (double)aReader[2];
                    dressTypes.Add(aDressType);
                }
            }
            connection.Close();
            return dressTypes;
        }
        #endregion

        #region Delivery
        public string UpdateOrderDelivery(int OrderIDforUpdate)
        {
            connection.Open();
            string query = string.Format("UPDATE OrderInfo SET DeliveryStatus={0}, PaymentStatus={1} WHERE OrderID={2}", 0,0, OrderIDforUpdate);
            SqlCommand command = new SqlCommand(query, connection);

            int affectedRows = command.ExecuteNonQuery();
            connection.Close();
            if (affectedRows > 0)
                return "Order Delivered successfully";
            return "Something wrong..!!";
        }
        public string CancilOrderDelivery(int OrderIDforUpdate)
        {
            connection.Open();
            string query = string.Format("UPDATE OrderInfo SET CancilStatus={0} WHERE OrderID={1}", 0, OrderIDforUpdate);
            SqlCommand command = new SqlCommand(query, connection);

            int affectedRows = command.ExecuteNonQuery();
            connection.Close();
            if (affectedRows > 0)
                return "Order Cancilled successfully";
            return "Something wrong..!!";
        }
        #endregion

        #region Supplier
        public string SaveSupplier(Supplier aSupplier)
        {
            connection.Open();
            string query = string.Format("INSERT INTO Supplier VALUES('{0}','{1}','{2}','{3}')", aSupplier.SupplierCode,aSupplier.SupplierName,aSupplier.SupplierAddress,aSupplier.SupplierMobile);
            SqlCommand command = new SqlCommand(query, connection);

            int affectedRows = command.ExecuteNonQuery();
            connection.Close();
            if (affectedRows > 0)
                return "Supplier Saved Successfully";
            return "Something went wrong.... ";
        }

        public string UpdateSupplier(Supplier aSupplier, string SupplierCode)
        {
            connection.Open();
            string query = string.Format("UPDATE Supplier SET SupplierAddress='{0}',SupplierMobile='{1}',SupplierName='{2}' WHERE SupplierID={3} AND SupplierCode='{4}'",aSupplier.SupplierAddress,aSupplier.SupplierMobile,aSupplier.SupplierName,aSupplier.SupplierID,SupplierCode);
            SqlCommand command = new SqlCommand(query, connection);

            int affectedRows = command.ExecuteNonQuery();
            connection.Close();
            if (affectedRows > 0)
                return "Supplier Updated Successfully";
            return "Something went wrong....";
        }
        public int GetMaxSupplierID()
        {
            connection.Open();
            string query = string.Format("SELECT MAX(SupplierID) FROM Supplier");
            SqlCommand command = new SqlCommand(query, connection);

            int maxId = Convert.ToInt32(command.ExecuteScalar());
            return maxId;
            connection.Close();
        }
        public int GetSupplierIDBySupplierCode(string supplierCode)
        {
            connection.Open();
            string query = string.Format("SELECT SupplierID FROM Supplier WHERE SupplierCode LIKE '{0}'", supplierCode);
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader aReader = command.ExecuteReader();
            int Id = 0;
            while (aReader.Read())
            {
                Id = (int)aReader["SupplierID"];
            }
            connection.Close();
            return Id;
        }

        public List<Supplier> GetAllSupplier()
        {
            connection.Open();
            string query = string.Format("SELECT * FROM Supplier ORDER BY SupplierID DESC");
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader aReader = command.ExecuteReader();
            List<Supplier> suppliers = new List<Supplier>();
            if (aReader.HasRows)
            {
                while (aReader.Read())
                {
                    Supplier aSupplier = new Supplier();
                    aSupplier.SupplierID = (int)aReader[0];
                    aSupplier.SupplierCode = aReader[1].ToString();
                    aSupplier.SupplierName = aReader[2].ToString();
                    aSupplier.SupplierAddress = aReader[3].ToString();
                    aSupplier.SupplierMobile = aReader[4].ToString();                   

                    suppliers.Add(aSupplier);
                }
            }
            connection.Close();
            return suppliers; 
        }

        public List<SupplierProduct> GetAllSupplierProduct()
        {
            connection.Open();
            string query = string.Format("SELECT Supplier.*,Material.MaterialCode,Material.MaterialName,Material.MaterialOtherInfo,Material.MaterialPrice,Material.MaterialQuantity,Material.PurchaseDate,Material.Unit,Material.MaterialID FROM Supplier join Material on Material.SupplierID=Supplier.SupplierID ORDER BY Supplier.SupplierID DESC");
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader aReader = command.ExecuteReader();
            List<SupplierProduct> supplierProducts = new List<SupplierProduct>();
            if (aReader.HasRows)
            {
                while (aReader.Read())
                {
                    SupplierProduct aSupplierProduct = new SupplierProduct();
                    aSupplierProduct.SupplierProductID= (int)aReader[0];
                    aSupplierProduct.SupplierCode = aReader[1].ToString();
                    aSupplierProduct.SupplierName = aReader[2].ToString();
                    aSupplierProduct.SupplierAddress = aReader[3].ToString();
                    aSupplierProduct.SupplierMobile = aReader[4].ToString();
                    aSupplierProduct.MaterialCode = aReader[5].ToString();
                    aSupplierProduct.MaterialName = aReader[6].ToString();
                    aSupplierProduct.OtherInformation = aReader[7].ToString();
                    aSupplierProduct.MaterialPrice = Convert.ToDouble(aReader[8]);
                    aSupplierProduct.MaterialQuantity = Convert.ToDouble(aReader[9]);
                    aSupplierProduct.PurchaseDate = Convert.ToDateTime(aReader[10]);
                    aSupplierProduct.MaterialUnit = aReader[11].ToString();
                    aSupplierProduct.MaterialID = (int)aReader[12];

                    supplierProducts.Add(aSupplierProduct);
                }
            }
            connection.Close();
            return supplierProducts; 
        }

        public List<SupplierProduct> GetAllSupplierProductBySupplierName(string supplierName)
        {
            connection.Open();
            string query = string.Format("SELECT Supplier.*,Material.MaterialCode,Material.MaterialName,Material.MaterialOtherInfo,Material.MaterialPrice,Material.MaterialQuantity,Material.PurchaseDate,Material.Unit,Material.MaterialID FROM Supplier join Material on Material.SupplierID=Supplier.SupplierID where Supplier.SupplierName LIKE '%{0}%' ORDER BY Supplier.SupplierID DESC", supplierName);
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader aReader = command.ExecuteReader();
            List<SupplierProduct> supplierProducts = new List<SupplierProduct>();
            if (aReader.HasRows)
            {
                while (aReader.Read())
                {
                    SupplierProduct aSupplierProduct = new SupplierProduct();
                    aSupplierProduct.SupplierProductID = (int)aReader[0];
                    aSupplierProduct.SupplierCode = aReader[1].ToString();
                    aSupplierProduct.SupplierName = aReader[2].ToString();
                    aSupplierProduct.SupplierAddress = aReader[3].ToString();
                    aSupplierProduct.SupplierMobile = aReader[4].ToString();
                    aSupplierProduct.MaterialCode = aReader[5].ToString();
                    aSupplierProduct.MaterialName = aReader[6].ToString();
                    aSupplierProduct.OtherInformation = aReader[7].ToString();
                    aSupplierProduct.MaterialPrice = Convert.ToDouble(aReader[8]);
                    aSupplierProduct.MaterialQuantity = Convert.ToDouble(aReader[9]);
                    aSupplierProduct.PurchaseDate = Convert.ToDateTime(aReader[10]);
                    aSupplierProduct.MaterialUnit = aReader[11].ToString();
                    aSupplierProduct.MaterialID = (int)aReader[12];

                    supplierProducts.Add(aSupplierProduct);
                }
            }
            connection.Close();
            return supplierProducts; 
        }
        public List<SupplierProduct> GetAllSupplierProductBySupplierMobile(string supplierMobile)
        {
            connection.Open();
            string query = string.Format("SELECT Supplier.*,Material.MaterialCode,Material.MaterialName,Material.MaterialOtherInfo,Material.MaterialPrice,Material.MaterialQuantity,Material.PurchaseDate,Material.Unit,Material.MaterialID FROM Supplier join Material on Material.SupplierID=Supplier.SupplierID where Supplier.SupplierMobile LIKE '%{0}%' ORDER BY Supplier.SupplierID DESC", supplierMobile);
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader aReader = command.ExecuteReader();
            List<SupplierProduct> supplierProducts = new List<SupplierProduct>();
            if (aReader.HasRows)
            {
                while (aReader.Read())
                {
                    SupplierProduct aSupplierProduct = new SupplierProduct();
                    aSupplierProduct.SupplierProductID = (int)aReader[0];
                    aSupplierProduct.SupplierCode = aReader[1].ToString();
                    aSupplierProduct.SupplierName = aReader[2].ToString();
                    aSupplierProduct.SupplierAddress = aReader[3].ToString();
                    aSupplierProduct.SupplierMobile = aReader[4].ToString();
                    aSupplierProduct.MaterialCode = aReader[5].ToString();
                    aSupplierProduct.MaterialName = aReader[6].ToString();
                    aSupplierProduct.OtherInformation = aReader[7].ToString();
                    aSupplierProduct.MaterialPrice = Convert.ToDouble(aReader[8]);
                    aSupplierProduct.MaterialQuantity = Convert.ToDouble(aReader[9]);
                    aSupplierProduct.PurchaseDate = Convert.ToDateTime(aReader[10]);
                    aSupplierProduct.MaterialUnit = aReader[11].ToString();
                    aSupplierProduct.MaterialID = (int)aReader[12];

                    supplierProducts.Add(aSupplierProduct);
                }
            }
            connection.Close();
            return supplierProducts; 
        }

        public List<Supplier> GetAllSupplierBySupplierID(int supplierID)
        {
            connection.Close();
            connection.Open();
            string query = string.Format("SELECT * FROM Supplier where Supplier.SupplierID='{0}' ORDER BY Supplier.SupplierID DESC",supplierID);
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader aReader = command.ExecuteReader();
            List<Supplier> suppliers = new List<Supplier>();
            if (aReader.HasRows)
            {
                while (aReader.Read())
                {
                    Supplier aSupplier = new Supplier();
                    aSupplier.SupplierID = (int)aReader[0];
                    aSupplier.SupplierCode = aReader[1].ToString();
                    aSupplier.SupplierName = aReader[2].ToString();
                    aSupplier.SupplierAddress = aReader[3].ToString();
                    aSupplier.SupplierMobile = aReader[4].ToString();

                    suppliers.Add(aSupplier);
                }
            }
            connection.Close();
            return suppliers; 
        }
        #endregion

        #region Material
        public string SaveMaterial(Material aMaterial)
        {
            connection.Open();
            string query = string.Format("INSERT INTO Material VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}')", aMaterial.MaterialName, aMaterial.MaterialPrice, aMaterial.MaterialQuantity, aMaterial.MaterialCode, aMaterial.MaterialOtherInfo, aMaterial.SupplierID, aMaterial.Unit,aMaterial.PurchaseDate);
            SqlCommand command = new SqlCommand(query, connection);

            int affectedRows = command.ExecuteNonQuery();
            connection.Close();
            if (affectedRows > 0)
                return "Material Saved Successfully";
            return "Something went wrong.... ";
        }
        public string UpdateProduct(Material aMaterial, int supplierID)
        {
            connection.Open();
            string query = string.Format("UPDATE Material SET MaterialName='{0}',MaterialPrice='{1}',MaterialQuantity='{2}',MaterialCode='{3}',MaterialOtherInfo='{4}',Unit='{5}',PurchaseDate='{6}' WHERE SupplierID={7}", aMaterial.MaterialName, aMaterial.MaterialPrice, aMaterial.MaterialQuantity, aMaterial.MaterialCode, aMaterial.MaterialOtherInfo, aMaterial.Unit, aMaterial.PurchaseDate, supplierID);
            SqlCommand command = new SqlCommand(query, connection);

            int affectedRows = command.ExecuteNonQuery();
            connection.Close();
            if (affectedRows > 0)
                return "Material Updated Successfully";
            return "Something wrong.... ";
        }
        public List<Material> GetAllMaterial()
        {
            connection.Close();
            connection.Open();
            string query = string.Format("SELECT * FROM Material ORDER BY MaterialID DESC");
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader aReader = command.ExecuteReader();
            List<Material> materials = new List<Material>();
            if (aReader.HasRows)
            {
                while (aReader.Read())
                {
                    Material aMaterial = new Material();
                    aMaterial.MaterialID = (int)aReader[0];
                    aMaterial.MaterialName = aReader[1].ToString();
                    aMaterial.MaterialPrice =(double)aReader[2];
                    aMaterial.MaterialQuantity =(double) aReader[3];
                    aMaterial.MaterialCode = aReader[4].ToString();
                    aMaterial.MaterialOtherInfo = aReader[5].ToString();
                    aMaterial.SupplierID = (int)aReader[6];
                    aMaterial.Unit = aReader[7].ToString();
                    aMaterial.PurchaseDate = Convert.ToDateTime(aReader[8]);
                    
                    materials.Add(aMaterial);
                }
            }
            connection.Close();
            return materials; 
        }
        //public string SaveOrderMaterial(OrderMaterial orderMaterial)
        //{
        //    connection.Open();
        //    string query = string.Format("INSERT INTO OrderMaterial VALUES('{0}','{1}','{2}','{3}','{4}')", orderMaterial.OrderID, orderMaterial.MaterialCode, orderMaterial.MaterialQuantity, orderMaterial.OrderMaterialDate, orderMaterial.OrderNo);
        //    SqlCommand command = new SqlCommand(query, connection);

        //    int affectedRows = command.ExecuteNonQuery();
        //    connection.Close();
        //    if (affectedRows > 0)
        //        return "Order Accesories Saved Successfully";
        //    return "Something went wrong.... ";
            
        //}
        public string SaveOrderMaterial(List<OrderMaterial> orderMaterialList)
        {
            
            int affectedRows = 0; 
            foreach (var aOrderMaterial in orderMaterialList)
            {
                connection.Open();
                string query = string.Format("INSERT INTO OrderMaterial VALUES('{0}','{1}','{2}','{3}','{4}')", aOrderMaterial.OrderID, aOrderMaterial.MaterialCode, aOrderMaterial.MaterialQuantity, aOrderMaterial.OrderMaterialDate, aOrderMaterial.OrderNo);
                SqlCommand command = new SqlCommand(query, connection);

                affectedRows = command.ExecuteNonQuery();
                connection.Close();
                //if (affectedRows > 0)
                //    return "Order Accesories Saved Successfully";
                //return "Something went wrong.... ";
            }
            if (affectedRows > 0)
                return "Orderwise Accesories Aquisition Successfull";
            return "Something went wrong.... ";
            
        }
        public string GetMaterialUnitByCode(string MaterialCode)
        {
            connection.Open();
            string query = string.Format("SELECT Unit FROM Material WHERE MaterialCode ='{0}'", MaterialCode);
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader aReader = command.ExecuteReader();
            string Unitname = "";
            while (aReader.Read())
            {
                Unitname = (string)aReader["Unit"];
            }
            connection.Close();
            return Unitname;
        }
        public List<OrderMaterial> GetOrderMaterialByOrderNo(string searchText)
        {
            connection.Open();
            string query = string.Format("SELECT OrderMaterial.*,Material.Unit FROM OrderMaterial Join Material on OrderMaterial.MaterialCode = Material.MaterialCode WHERE OrderMaterial.OrderNo= '{0}'", searchText);
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader aReader = command.ExecuteReader();
            List<OrderMaterial> OrderMaterials = new List<OrderMaterial>();
            if (aReader.HasRows)
            {
                while (aReader.Read())
                {
                    OrderMaterial aOrderMaterial = new OrderMaterial();
                    aOrderMaterial.OrderMaterialID = (int)aReader[0];
                    aOrderMaterial.OrderID = (int)aReader[1];
                    aOrderMaterial.MaterialCode = aReader[2].ToString();
                    aOrderMaterial.MaterialQuantity = (double)aReader[3];
                    aOrderMaterial.OrderMaterialDate = Convert.ToDateTime(aReader[4]);
                    aOrderMaterial.OrderNo = aReader[5].ToString();
                    aOrderMaterial.MaterialUnit = aReader[6].ToString();
                    OrderMaterials.Add(aOrderMaterial);
                }
            }
            connection.Close();
            return OrderMaterials;
        }

        public List<OrderMaterial> GetMaterialRequsitionBetweenFromToDate(string fromDATE, string toDATE)
        {
            connection.Open();
            string query = string.Format("SELECT OrderMaterial.*,Material.Unit FROM OrderMaterial Join Material on OrderMaterial.MaterialCode = Material.MaterialCode WHERE OrderMaterial.Date>='{0}' AND OrderMaterial.Date <='{1}'", fromDATE, toDATE);
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader aReader = command.ExecuteReader();
            List<OrderMaterial> OrderMaterials = new List<OrderMaterial>();
            if (aReader.HasRows)
            {
                while (aReader.Read())
                {
                    OrderMaterial aOrderMaterial = new OrderMaterial();
                    aOrderMaterial.OrderMaterialID = (int)aReader[0];
                    aOrderMaterial.OrderID = (int)aReader[1];
                    aOrderMaterial.MaterialCode = aReader[2].ToString();
                    aOrderMaterial.MaterialQuantity = (double)aReader[3];
                    aOrderMaterial.OrderMaterialDate = Convert.ToDateTime(aReader[4]);
                    aOrderMaterial.OrderNo = aReader[5].ToString();
                    aOrderMaterial.MaterialUnit = aReader[6].ToString();
                    OrderMaterials.Add(aOrderMaterial);
                }
            }
            connection.Close();
            return OrderMaterials;
        }
        public bool HasthisOrderNo(string orderNo)
        {
            connection.Open();
            String query = String.Format("SELECT * FROM OrderMaterial WHERE OrderNo='{0}'", orderNo);
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader aReader = command.ExecuteReader();
            bool Hassrow = aReader.HasRows;
            connection.Close();
            return Hassrow;
        }
        public string DeleteOrderMaterial(string orderNo)
        {            
            connection.Open();
            String query = String.Format("DELETE FROM OrderMaterial WHERE OrderMaterial.OrderNo='{0}'", orderNo);
            SqlCommand command = new SqlCommand(query, connection);
            int affectedRows = command.ExecuteNonQuery();
            connection.Close();
            if (affectedRows > 0)
                return "OrderMaterial Deleted Successfully";
            return "Something went wrong.... ";
        }
        public List<Material> GetAllMaterialBySupplierID(int supplierID)
        {
            connection.Close();
            connection.Open();
            string query = string.Format("SELECT * FROM Material where Material.SupplierID='{0}' ORDER BY MaterialID DESC",supplierID);
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader aReader = command.ExecuteReader();
            List<Material> materials = new List<Material>();
            if (aReader.HasRows)
            {
                while (aReader.Read())
                {
                    Material aMaterial = new Material();
                    aMaterial.MaterialID = (int)aReader[0];
                    aMaterial.MaterialName = aReader[1].ToString();
                    aMaterial.MaterialPrice = (double)aReader[2];
                    aMaterial.MaterialQuantity = (double)aReader[3];
                    aMaterial.MaterialCode = aReader[4].ToString();
                    aMaterial.MaterialOtherInfo = aReader[5].ToString();
                    aMaterial.SupplierID = (int)aReader[6];
                    aMaterial.Unit = aReader[7].ToString();
                    aMaterial.PurchaseDate = Convert.ToDateTime(aReader[8]);

                    materials.Add(aMaterial);
                }
            }
            connection.Close();
            return materials;  
        }

        #endregion

        #region DressType
        public string SaveDressType(DressType aDressType)
        {
            connection.Open();
            string query = string.Format("INSERT INTO DressType VALUES('{0}','{1}')", aDressType.TypeName, aDressType.DressPrice);
            SqlCommand command = new SqlCommand(query, connection);

            int affectedRows = command.ExecuteNonQuery();
            connection.Close();
            if (affectedRows > 0)
                return "Dress Type Saved Successfully";
            return "Something went wrong...... ";
        }

        public List<DressType> GetAllDressTypeByID(int dressTypeID)
        {
            connection.Open();
            string query = string.Format("SELECT * FROM DressType WHERE DressTypeID ='{0}'", dressTypeID);
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader aReader = command.ExecuteReader();
            List<DressType> dressTypes = new List<DressType>();
            if (aReader.HasRows)
            {
                while (aReader.Read())
                {
                    DressType aDressType = new DressType();
                    aDressType.DressTypeID = (int)aReader[0];
                    aDressType.TypeName = aReader[1].ToString();
                    aDressType.DressPrice = (double)aReader[2];
                    dressTypes.Add(aDressType);
                }
            }
            connection.Close();
            return dressTypes;
        }

        public string UpdateDressType(DressType aDressType, int DressTypeID)
        {
            connection.Open();
            string query = string.Format("UPDATE DressType SET TypeName='{0}', Price='{1}' WHERE DressTypeID={2}", aDressType.TypeName, aDressType.DressPrice, DressTypeID);
            SqlCommand command = new SqlCommand(query, connection);

            int affectedRows = command.ExecuteNonQuery();
            connection.Close();
            if (affectedRows > 0)
                return "DressType Updated successfully";
            return "Something wrong..!!";
        }
        #endregion










        
    }
}