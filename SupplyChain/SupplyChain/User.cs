using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SupplyChain {
    public class User {
        int userId;
        String name;
        String email;
        String password;
        UserType userType;
    }
    public enum UserType {
        Admin, Producer, Transporter
    }
}