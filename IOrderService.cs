using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Data;

namespace SPWcfExample
{
    [ServiceContract(Namespace = "http:www.Test.com/SPWcfExample/OrderService/2012/06", Name = "OrderService")]
    public interface IOrderService
    {
        [OperationContract]
        [WebInvoke(Method = "GET", BodyStyle = WebMessageBodyStyle.Wrapped,
            RequestFormat = WebMessageFormat.Xml, 
            UriTemplate = "/GetOrder/{customerName}")]
            Order GetOrder(string CustomerName);

        [OperationContract]
        [WebInvoke(Method = "POST", 
            BodyStyle = WebMessageBodyStyle.Wrapped,
            RequestFormat = WebMessageFormat.Xml, 
            UriTemplate = "/PlaceOrder")]
        int PlaceOrder(Order order);

        [OperationContract]
        [WebInvoke(Method = "GET", 
            BodyStyle = WebMessageBodyStyle.Wrapped,
            RequestFormat = WebMessageFormat.Xml, 
            UriTemplate = "/Test")]
        string Test();

        [OperationContract]
        [WebInvoke(Method = "GET", 
            BodyStyle = WebMessageBodyStyle.Wrapped,
            RequestFormat = WebMessageFormat.Xml,
            UriTemplate = "GetData/all")]
        List<Employee> GetAllEmployeesMethod();
    }

    [DataContract(Namespace = "http:www.Test.com/SPWcfExample/OrderService/2012/06", Name = "Order")]
    public class Order
    {

        [DataMember]
        public int OrderNumber { get; set; }
        [DataMember]
        public int ProductNumber { get; set; }
        [DataMember]
        public int Quantity { get; set; }
        [DataMember]
        public string CustomerName { get; set; }
    }

    [DataContract]
    public class Employee
    {
        [DataMember]
        public string firstname { get; set; }
        [DataMember]
        public string lastname { get; set; }
        [DataMember]
        public decimal salary { get; set; }
        public Employee(string first, string last, decimal sal)
        {
            firstname = first;
            lastname = last;
            salary = sal;
        }
    }
}
