using System;
using System.Collections.Generic;
using System.Text;

namespace MyQH_Mobile_Test.Utilities.DataModels
{
    class Login
    {
    }

    public class LoginBody
    {
        public string? userName { get; set; }
        public string? password { get; set; }
        public int? groupId { get; set; }
    }
    public class LoginResponse
    {
        public string? token { get; set; }
        public string? jwt { get; set; }
        public bool? passwordChangeRequired { get; set; }
        public bool? forcePasswordUpdate { get; set; }
        public int? qhid { get; set; }
        public bool? shouldRequestMultiFactorAuthentication { get; set; }
    }
}
