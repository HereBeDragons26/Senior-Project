using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SupplyChain {
    public class User {
        private int userId { get; set; }
        private int companyId { get; set; }
        private String name { get; set; }
        private String email { get; set; }
        private String password { get; set; }
        private UserType userType { get; set; }
    }
    public enum UserType {
        Admin, Producer, Transporter
    }
}